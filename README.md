```
This is a very simple Chat System that is written in C# using the .NET Framework.
The application has two parts: the server side and the client side.
The client have symmetric encryption and the server side generate a key for the client to validate the post request.
```
# Server side
On the server side, there are two methods: HandlePostRequest and HandleGetRequest. The server runs a website on your local host with a simple user interface and display the chat messages that are encrypted.
# Client side
On the client side, there are three main functions: sending messages to the website, receiving recent messages, and checking which users are online. The client has a simple user interface that is done with Windows Forms.
# To improve
You can change the code to allow real-time communication between the server and the client. The main problem with the current code is that it sends a GET request every second, which can lead to a server-side error '429'. One solution to this issue is to use a websockets library.

