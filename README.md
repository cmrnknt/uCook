You can just run the C# server from visual studio on IIS Express to query it


To test c# backend:
http://localhost:<portNum>/swagger

Test data for the server: 
POST (Create)
'{"title":"sdsd","summary":"wewe"}'

GET
You can just use the try it out button

GET (Id)
if you do a valid id (1) it will return the object
else (130)
It will return an empty object. 
I would have handled this better with error objects if I had more time.

DELETE
Choose an ID that is not deleted (4)
Sets the deleted flag to true for an object. We never want to actually delete data
//as it may come in handy for data mining at a later point


PUT (Update):
'{
  "Id": 8,
  "Title": "newvaluetitle",
  "Summary": "newvaluesummary",
  "DateCompleted": "2017-11-01T22:47:40.082Z"
}'


Client:
*This assumes you have Node, GitBash and Yarn installed
navigate to the client App
yarn install
then once it has installed
yarn run

This wont display too much now but there is some logging in the console.
you can also navigate to http://localhost:3000/add 
(it should still be on that port by default)



