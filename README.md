# SharpMiner
A tool for mining edit-patterns from C# code.


# Prerequisites

    You have to install srcML if you want to diff C++ and C# code

Usage:
 - PATH Amount-of-commits MODE
 - PATH MODE
 
The path is a path a git object.
The mode is one of two current implemented modes:
  - Bigcluster: Returns a big JSON with all the edits into one cluster (might take a while and contains a lot of useless edits)
  - RelevantCluster: Returns all the relevant clusters
