package be.vub

import java.io.{ByteArrayOutputStream, OutputStream}
import org.eclipse.jgit.diff.DiffEntry
import org.eclipse.jgit.lib.{ObjectId, ObjectLoader, ObjectReader}
import org.eclipse.jgit.revwalk.{RevCommit, RevTree, RevWalk}
import org.eclipse.jgit.treewalk.CanonicalTreeParser

import scala.jdk.CollectionConverters._


class Commit(commitIdHash : String , repository: Repository) {

  def getCommitIdHash: String = commitIdHash

  private val allChangedFiles : List[ChangedFile] = {
    //find the first previous commit
    val git = repository.getGit
    val commitId : ObjectId = git.getRepository.resolve(commitIdHash)
    val revWalk : RevWalk = new RevWalk(git.getRepository)
    val revCommit : RevCommit = revWalk.parseCommit(commitId)
    val revCommitTree : RevTree = revCommit.getTree
    val revPreviousCommit : RevCommit = revCommit.getParent(0)
    revWalk.parseHeaders(revPreviousCommit)
    val previousCommitId : ObjectId = revPreviousCommit.getTree
    revWalk.close()

    //Get trees for each commit
    val reader : ObjectReader = git.getRepository.newObjectReader()
    val oldTreeIter : CanonicalTreeParser = new CanonicalTreeParser()
    oldTreeIter.reset(reader, previousCommitId)
    val newTreeIter : CanonicalTreeParser = new CanonicalTreeParser()
    newTreeIter.reset(reader,revCommitTree)

    def fetchSource(objectId: ObjectId): String ={
      val loader : ObjectLoader = git.getRepository.open(objectId)
      val out : OutputStream = new ByteArrayOutputStream()
      loader.copyTo(out)
      out.toString
    }

    var currentChangedFiles : List[ChangedFile] = List[ChangedFile]()
    //Get list of changed files
    val diffs : List[DiffEntry] = git.diff().setNewTree(newTreeIter).setOldTree(oldTreeIter).call().asScala.toList
    for(entry : DiffEntry <- diffs){
      if ((entry.getChangeType == DiffEntry.ChangeType.MODIFY)&& entry.toString.contains(".cs")) {
        var loop = 0
        while(loop < 3){
          try{
            val file : ChangedFile = new ChangedFile(this,
            fetchSource(entry.getNewId.toObjectId),
            fetchSource(entry.getOldId.toObjectId))
            currentChangedFiles = currentChangedFiles.::(file)
            loop = 3
          }
          catch {
            case _: Throwable => loop += 1
          }
        }


      }

    }
    currentChangedFiles
  }

  def getAllChangedFiles : List[ChangedFile] = allChangedFiles

  private val allConcreteEdits : List[Edit] = {
    var allEdits : List[Edit] = List()
    for(changedFile <- allChangedFiles){
      allEdits = changedFile.getConcreteEdits:::allEdits
    }
    allEdits
  }

  def getAllConcreteEdits : List[Edit] = allConcreteEdits

}
