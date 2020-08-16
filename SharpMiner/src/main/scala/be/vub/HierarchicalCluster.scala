package be.vub

import java.io.{BufferedWriter, File, FileWriter}

import scala.collection.mutable
import scala.collection.parallel.CollectionConverters._
import scala.collection.parallel.mutable.ParArray
import scala.math.floorMod

class HierarchicalCluster(edits : List[Edit]) {
  private var activeClusters : ParArray[Edit] = ArrayIsParallelizable(edits.toArray).par
  val hole = 7200
  //Pick a pair e1, e2
  //Generalize the edit pattern using anti-unification
  //remove e1, e2 and add e3 instead
  //set e3 as the parent of e1 and e2

  private val s: mutable.Stack[Edit] = mutable.Stack()

  def findClosest(current: Edit) : (Edit,EditPattern) = {
    var closest : Edit = current
    var closestEditPattern : EditPattern = null
    var closestDistance : Int = -1
    for{cluster <- activeClusters.filter(_ != current).seq} {
      val editPattern = new EditPattern(cluster,current)
      val distance = editPattern.getDistance
      if ((distance < closestDistance) || (closestDistance == -1)) {
        closest = cluster
        closestEditPattern = editPattern
        closestDistance = distance
      }
    }
    (closest,closestEditPattern)
  }

  @scala.annotation.tailrec
  private def nearestNeighbourChain(): Unit = {
    if(s.isEmpty){
      s.push(activeClusters.head)
    }
    val current: Edit = s.pop()
    s.push(current)
    val closest = findClosest(current)
    if(s.contains(closest._1)){
      s.pop()
      s.remove(s.indexOf(closest._1))
      activeClusters = closest._2 +: activeClusters.filter(_ != closest._1).filter(_ != current)
    } else {
      s.push(closest._1)
    }
    if(activeClusters.length != 1){
      nearestNeighbourChain()
    }
  }

  private val result : Edit = {
    nearestNeighbourChain()
    activeClusters.head
  }

  def getResult : Edit = result

  private def writeEdit(edit: Edit): Unit = {
    val newFile = new File("out\\json\\Edits\\edit" + edit.getID + ".json")
    val newbw = new BufferedWriter(new FileWriter(newFile))
    ujson.writeTo(edit.editToJSON, newbw, 4)
    newbw.close()
  }

  def resultAsJSON(): ujson.Arr = {
    def clusterToJSON(edit : Edit): ujson.Arr ={
      val left = edit.getLeft
      val right = edit.getRight
      var children = List[ujson.Arr]()
      if(left != null && right != null){
        children = clusterToJSON(left) :: clusterToJSON(right) :: children
      }
      var importance = false
      if(!(floorMod(edit.getBeforeTree.getType,10000)  == hole) && !(floorMod(edit.getAfterTree.getType,10000) == hole)){
        writeEdit(edit)
        importance = true
      }
      ujson.Arr(
        ujson.Obj("Reference"-> edit.getID,"importance"->importance ,"distance"-> edit.getDistance,"Children"-> children)
      )
    }
    val dir1 = new File("out\\json")
    var successful1 = dir1.mkdir
    while(!successful1){
      successful1=dir1.mkdir()
      println("unsuccesfull 1")
    }
    val dir2 = new File("out\\json\\Edits")
    var successful2 = dir2.mkdir
    while(!successful2){
      successful2=dir2.mkdir()
      println("unsuccesfull 2")
    }
    val json = clusterToJSON(result)
    val newFile = new File("out\\json\\Cluster.json")
    println("writing:")
    val newbw = new BufferedWriter(new FileWriter(newFile))
    ujson.writeTo(json, newbw, 4)
    newbw.close()
    json
  }

  def clustersToJSON() : Unit = {
    def childrenToJSON(edit: Edit): ujson.Arr = {
        val left = edit.getLeft
        val right = edit.getRight
        var children = List[ujson.Arr]()
        if(left != null && right != null){
          children = childrenToJSON(left) :: childrenToJSON(right) :: children
        }
        if(!(floorMod(edit.getBeforeTree.getType,10000)  == hole) && !(floorMod(edit.getAfterTree.getType,10000) == hole)){
          writeEdit(edit)

        }
      ujson.Arr(
        ujson.Obj("Reference"-> edit.getID,"distance"-> edit.getDistance,"Children"-> children)
      )
    }
    def clusterToJSON(edit : Edit): Unit ={
      val left = edit.getLeft
      val right = edit.getRight

      if(!(floorMod(edit.getBeforeTree.getType,10000)  == hole) && !(floorMod(edit.getAfterTree.getType,10000) == hole)){
        writeEdit(edit)
        val newFile = new File("out\\json\\Clusters\\Cluster"+ edit.getID + ".json")
        var children = List[ujson.Arr]()
        if(left != null && right != null){
          children = childrenToJSON(left) :: childrenToJSON(right) :: children
        }
        val json = ujson.Arr(
          ujson.Obj("Reference"-> edit.getID,"distance"-> edit.getDistance,"Children"-> children)
        )
        val newbw = new BufferedWriter(new FileWriter(newFile))
        ujson.writeTo(json, newbw, 4)
        newbw.close()
      } else {
        if(left != null && right != null){
          clusterToJSON(left)
          clusterToJSON(right)
        }
      }
    }
    val dir1 = new File("out\\json")
    var successful1 = dir1.mkdir
    while(!successful1){
      successful1=dir1.mkdir()
      println("unsuccesfull 1")
    }
    val dir2 = new File("out\\json\\Edits")
    var successful2 = dir2.mkdir
    while(!successful2){
      successful2=dir2.mkdir()
      println("unsuccesfull 2")
    }
    val dir3 = new File("out\\json\\Clusters")
    var successful3 = dir3.mkdir
    while(!successful3){
      successful3=dir3.mkdir()
      println("unsuccesfull 3")
    }
    clusterToJSON(result)
  }
}
