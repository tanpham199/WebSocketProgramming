namespace _1712150_BTTH01
{
    public static class HtmlClient
    {
        public const string HTML =
@"<!DOCTYPE html>
<html lang=""en"">

<head>
    <meta charset = ""UTF-8"" >
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <title>Login</title>

    <style>
        * {
            max-width: 600px;
            margin: 0 auto;
            padding: 0;
            box-sizing: border-box;
        }

    html,
        body {
            background-color: #fff;
            color: #555;
            font-family: 'Lato', 'Arial', sans-serif;
            font-weight: 300;
            font-size: 20px;
            text-rendering: optimizeLegibility;
        }

h1 {
            margin-top: 50px;
            margin-bottom: 50px;
            font-size: 240%;
            word-spacing: 4px;
            letter-spacing: 1px;
        }

        input[type = input] {
            width: 100%;
            padding: 7px;
            border-radius: 3px;
            border: 1px solid #ccc;
        }

        input[type = button] {
            width: 100%;
            display: inline-block;
            padding: 10px 30px;
            font-weight: 300;
            text-decoration: none;
            border-radius: 200px;
            background-color: skyblue;
            border: 1px solid skyblue;
            color: #fff;
            margin-top: 30px;
        }

        div {
            display: none;
        }
    </style>
</head>

<body>
    <script language = ""javascript"" type=""text/javascript"">

        var wsUri = ""ws://127.0.0.1:8807/"";
var output;
var websocket;

function init()
{
    output = document.getElementById(""output"");
    configWebSocket();
}

function configWebSocket()
{
    websocket = new WebSocket(wsUri);
    websocket.onopen = function(evt) { onOpen(evt) };
    websocket.onclose = function(evt) { onClose(evt) };
    websocket.onmessage = function(evt) { onMessage(evt) };
    websocket.onerror = function(evt) { onError(evt) };
}

function onOpen(evt)
{
    emit(""SOCKET OPENED"");
}

function onClose(evt)
{
    emit(""SOCKET CLOSED"");
}

function onMessage(evt)
{
    if (evt.data === ""admin / admin"")
        emit('<head><meta http-equiv=""Refresh"" content=""0; URL=http://127.0.0.1:8887/info.html""></head>');
    else
        emit('<head><meta http-equiv=""Refresh"" content=""0; URL=http://127.0.0.1:8887/404.html""></head>');
}

function onError(evt)
{
    emit('<span style=""color:red;"">ERROR: ' + evt.data + '</span>');
}

function sendTextFrame(message)
{
    if (websocket.readyState == WebSocket.OPEN)
    {
        emit(""SENT: "" + message);
        websocket.send(message);
    }
    else
    {
        emit(""Socket not open, state: "" + websocket.readyState);
    }
}

function emit(message)
{
    var pre = document.createElement(""p"");
    pre.style.wordWrap = ""break-word"";
    pre.innerHTML = message;
    output.appendChild(pre);
}

function clickSend()
{
    var txtUser = document.getElementById(""user"");
    var txtPass = document.getElementById(""pass"");
    if (txtUser.value.length > 0 && txtPass.value.length > 0)
    {
        sendTextFrame(txtUser.value + "" / "" + txtPass.value);
        txtUser.value = """";
        txtPass.value = """";
        txtUser.focus();
        txtPass.focus();
    }
}

function clickClose()
{
    if (websocket.readyState == WebSocket.OPEN)
    {
        websocket.close();
    }
    else
    {
        emit(""Socket not open, state: "" + websocket.readyState);
    }
    document.getElementById(""sender"").disabled = true;
    document.getElementById(""closer"").disabled = true;
    document.getElementById(""user"").disabled = true;
    document.getElementById(""pass"").disabled = true;
}

window.addEventListener(""load"", init, false);

    </script>

    <h1>Login Form</h1>
    <form action = ""/action_page.php"" method= ""get"" >
        <label for=""user"">Username:</label><br><br>
        <input type = ""input"" id= ""user"" onkeyup= ""if(event.key==='Enter') clickSend()""><br><br>
        <label for=""pass"">Password:</label><br><br>
        <input type = ""input"" id= ""pass"" onkeyup= ""if(event.key==='Enter') clickSend()""><br><br>
        <input type= ""button"" id= ""sender"" value= ""Login"" onclick= ""clickSend()"" >
    </form>

    <div id=""output""></div>
</body>

</html>";
    }
}
