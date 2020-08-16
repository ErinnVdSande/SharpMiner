package be.vub

import com.github.gumtreediff.tree.ITree

class ConcreteEdit(beforeTree : ITree , afterTree : ITree , commits : List[String]) extends Edit {

  override def getBeforeTree : ITree = beforeTree

  override def getAfterTree : ITree = afterTree

  override def getLeft: Edit = null

  override def getRight: Edit = null

  override def getCommitIds: List[String] = commits

  override def getDistance: Int = 0
}
