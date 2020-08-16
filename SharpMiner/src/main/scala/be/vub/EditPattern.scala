package be.vub

import com.github.gumtreediff.tree.ITree

import scala.jdk.CollectionConverters._
import scala.math.floorMod

//Mapping is wat overeenkomt
//We moeten de edits hebben
//Definition 3.2 (Tree edits).
//Edit = Tree × Tree × PMapping
//Mapping = TreeRef × TreeRef × {mod, unmod}
//Voor een edit is zowel een change(wat verschillend is) als een mapping (wat over een komt)
class EditPattern(edit1: Edit , edit2 : Edit) extends Edit {
  //information from the first edit
  private val before1 = edit1.getBeforeTree
  private val after1 = edit1.getAfterTree

  //information from the second edit
  private val before2 = edit2.getBeforeTree
  private val after2 = edit2.getAfterTree

  //Give back the same hole if the nodes are actually the same
  val hole = 7200

  private def memoizedReplacementNode: (Int , Int) => Int = {
    var id = 0
    def getHole(): Int = {
      id += 1

      id * 10000 + hole
    }
    val cache = collection.mutable.Map.empty[(Int,Int),Int]

    (type1 , type2) => cache.getOrElse((type1 , type2),{
      cache update((type1 , type2), getHole())
      cache((type1,type2))
    })
  }

   private val getReplacement : (Int , Int) => Int = memoizedReplacementNode

  //Anti-unification for tree patterns/trees from the edit patterns/edits
  private def antiUnify(tree1 : ITree ,tree2 : ITree ) : ITree = {
    val resultTree = tree1.deepCopy()
    var loss = 0
    def recursiveTreeWalk(tree1: ITree ,tree2: ITree , result: ITree): Unit = {
    if(floorMod(tree1.getType,10000)  == hole || floorMod(tree1.getType,10000)  == hole){
      if(tree1.getLabel == tree2.getLabel){
        result.setType(getReplacement(tree1.getType,tree2.getType))
        result.setChildren(List[ITree]().asJava)
        loss = loss + 2 + 2*tree1.getDescendants.size() + 2*tree2.getDescendants.size()
      } else {
        result.setLabel("?")
        result.setType(getReplacement(tree1.getType,tree2.getType))
        result.setChildren(List[ITree]().asJava)
        loss = loss + 4 + 2*tree1.getDescendants.size() + 2*tree2.getDescendants.size()
      }
    } else if(tree1.hasSameTypeAndLabel(tree2) && (tree1.getChildren.size == tree2.getChildren.size)){
      val childrenTree1 : List[ITree] = tree1.getChildren.asScala.toList
      val childrenTree2 : List[ITree] = tree2.getChildren.asScala.toList
      val childrenResult : List[ITree] = result.getChildren.asScala.toList
      for ((children, childResult) <- childrenTree1.zip(childrenTree2).zip(childrenResult)) {
        val child1 = children._1
        val child2 = children._2
        recursiveTreeWalk(child1,child2,childResult)
      }
    } else if(tree1.getLabel == tree2.getLabel){
      result.setType(getReplacement(tree1.getType,tree2.getType)) //
      result.setChildren(List[ITree]().asJava)
      loss = loss + 2 + 2*tree1.getDescendants.size() + 2*tree2.getDescendants.size()

    } else {
      result.setLabel("?")
      result.setType(getReplacement(tree1.getType,tree2.getType))
      result.setChildren(List[ITree]().asJava)
      loss = loss + 4 + 2*tree1.getDescendants.size() + 2*tree2.getDescendants.size()
    }
  }
    recursiveTreeWalk(tree1,tree2,resultTree)
    lostInfo += loss
    resultTree
  }

  private var lostInfo = 0

  //Information calculated for the general edit

  private val beforeG = antiUnify(before1,before2)
  private val afterG = antiUnify(after1,after2)

  override def getBeforeTree : ITree = beforeG

  override def getAfterTree : ITree = afterG

  override def getLeft: Edit = edit1

  override def getRight: Edit = edit2

  def getDistance : Int =lostInfo

  private val commitIds = edit1.getCommitIds:::edit2.getCommitIds
  
  override def getCommitIds: List[String] = commitIds
}
