
# Pub Sub Example

This repo showcases a simple action delegate implementation of the publish/subscribe pattern in C#

The interfaces are designed so that they can be extended to support inter process communication and even machine to machine communication if necessary. The current implementation is in-process only at the moment.


## Running

Open the sln and run the app. The example is a simple console app that asks for an input and subscribes 10 object to the output. The console is used to display the subscriber's data.