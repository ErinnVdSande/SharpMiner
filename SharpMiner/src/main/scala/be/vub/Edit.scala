package be.vub

import com.github.gumtreediff.tree.ITree

import scala.jdk.CollectionConverters._

abstract class Edit() {
  def getID : Int = id

  private val id = Edit.getId

  def getCommitIds : List[String]

  def getBeforeTree : ITree

  def getAfterTree : ITree

  def getLeft : Edit

  def getRight : Edit

  def getDistance : Int

  def editToJSON : ujson.Arr = {
    def ITreeToJSON(tree : ITree) : ujson.Arr ={
      val children = tree.getChildren.asScala
      var childrenAsJSON = List[ujson.Arr]()
      if(children.nonEmpty){
        for(child <- children){
          childrenAsJSON = ITreeToJSON(child) :: childrenAsJSON
        }
      }
      val output = ujson.Arr(
        ujson.Obj("Label"->tree.getLabel,"Type"->tree.getType,"Children"->childrenAsJSON)
      )
      output
    }

    val output = if(getLeft!= null && getRight != null){
      ujson.Arr(
        ujson.Obj("Before Tree"->ITreeToJSON(getBeforeTree),"After Tree"->ITreeToJSON(getAfterTree), "Left" -> getLeft.getID, "Right" -> getRight.getID ,"Commit id's"->getCommitIds)
      )
    } else {
      ujson.Arr(
        ujson.Obj("Before Tree"->ITreeToJSON(getBeforeTree),"After Tree"->ITreeToJSON(getAfterTree),"Commit id's"->getCommitIds)
      )
    }
    output
  }
}

object Edit {
  private var id = 0
  def getId: Int = {
    id += 1
    id
  }
}