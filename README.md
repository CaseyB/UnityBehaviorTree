UnityBehaviorTree
=================

An implementation of [Behavior Trees](http://en.wikipedia.org/wiki/Behavior_Trees) in C# for Unity.  This implementation is based on this article: [Behavior trees for AI: How they work](http://outforafight.wordpress.com/2014/07/15/behaviour-behavior-trees-for-ai-dudes-part-1/).

Project Structure
-----------------
In the Unity Package the folder structure is as follows:

    Assets
    |-Scenes
    |-Scripts
    | |-Example Behaviors
    |
    |-Standard Assets
      |-BehaviorTrees
        |-Base
        |-CompositeNodes
        |-NodeDecorators

In the Scenes and Example Behaviors folders are examples that we use to test as we are building the library. In the Scripts folder is the BehaviorTree MonoBehavior that will be attached to your GameObject to act as the root of the behavior tree.  The Standard Assets/BehaviorTrees folder contains all of the Node classes for  building the tree and implementing your own Leaf Nodes.

Implemented Nodes
-----------------
### Sequence
This is the simplest Composite Node.  It runs its children in order until it gets a failure.

### Selector
This Composite Node lets you prioritize behavior options and run them in order until one succeeds.

### Inverter
This is a Node Decorator that inverts the return of it's child Node.  For example, if you have a node to check for nearby enemies that will return FAILURE when there are one you can put an Inverter on that to tell you if you're in a safe spot (i.e. there are no enemies nearby).

### Repeat
This Node Decorator repeats it's child Node either a certain number of times or forever.

### RepeatUntilFailure
This Node Decorator repeats it's child Node until that Node returns FAILURE.

### Succeeder
This Node Decorator ignores the Result returned from its child Node and always return SUCCESS.

Custom Nodes
------------
To implement your own Leaf Nodes just extend the Node class and implement the Init and Process methods.
