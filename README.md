
1. Fill your db info according below and paste it in appsettings.json 
 "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=your_db_name;User=userName;Password=yourDbPassword;"
  },

2. In Package Manager Console, execute these commands: 
 1.<code> Add-Migration migrationName</code>
 2.<code> Update-Database</code>

<b>To Test the hub, you need 2 registered user ids in the app!</b>

1. In the Postman create WebSocket request and paste the link: 
<code>localhost:5062/chatHub</code>

2. Send 
<json>{
  "protocol": "json",
  "version": 1
}</json> 
request to the server.
<b>Both users have to send this request in order to connect to the hub</b>

3. Send message request:
{
  "type": 1,
  "invocationId": "0",
  "target": "SendDirectMessage",
  "arguments": [
    "userId",
    "message"
  ]
}

