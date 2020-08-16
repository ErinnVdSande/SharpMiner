package be.vub

object HelloWorld {
  def main(args: Array[String]): Unit = {
    if(args.length == 3){
      println("Start")
      println("Get commits: ")
      val edits = new Repository(args[0].toString()).getCommits("master")
      println("V")
      println("Amount of edits : " + edits.length)
      println("start clustering: ")
      val cluster = new HierarchicalCluster(edits.take(args[1].toString().toInt).flatMap(_.getAllConcreteEdits))
      println("V")
      println("create json: ")
      val mode = args[2].toString()
      if(mode == "BigCluster"){
        cluster.resultAsJSON()
      } else if(mode == "RelevantCluster"){
        cluster.clustersToJSON()
      }
      println("V")
    } else if(args.length == 2){
      println("Start")
      println("Get commits: ")
      val edits = new Repository(args[0].toString()).getCommits("master").flatMap(_.getAllConcreteEdits)
      println("V")
      println("Amount of edits : " + edits.length)
      println("start clustering: ")
      val cluster = new HierarchicalCluster(edits)
      println("V")
      println("create json: ")
      val mode = args[1].toString()
      if(mode == "BigCluster"){
        cluster.resultAsJSON()
      } else if(mode == "RelevantCluster"){
        cluster.clustersToJSON()
      }
      println("V")
    } else {
      println("Unknown command")
      println("available commands are : ")
      println("- path (BigCluster|RelevantCluster)")
      println("- path amount (BigCluster|RelevantCluster)")
    }

  }
}
