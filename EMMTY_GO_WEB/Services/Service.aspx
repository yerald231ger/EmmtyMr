﻿<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Service.aspx.cs" Inherits="Service" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>Comet AJAX Sample</title>
    
    <script type="text/javascript">
        function getData() {
            loadXMLDoc("Service.aspx");
        }

        var req = false;

        function createRequest() {
            // branch for native XMLHttpRequest object
            if (window.XMLHttpRequest && !(window.ActiveXObject)) {
                try {
                    req = new XMLHttpRequest();
                } catch (e) {
                    req = false;
                }
                // branch for IE/Windows ActiveX version
            } else if (window.ActiveXObject) {
                try {
                    req = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (e) {
                    try {
                        req = new ActiveXObject("Microsoft.XMLHTTP");
                    } catch (e) {
                        req = false;
                    }
                }
            }
        }

        function loadXMLDoc(url) {
            try {
                if (req) {
                    req.abort();
                    req = false;
                }

                createRequest();

                if (req) {
                    req.onreadystatechange = processReqChange;
                    req.open("GET", url, true);
                    req.send("");
                }
                else {
                    alert('unable to create request');
                }
            }
            catch (e) {
                alert(e.message);
            }
        }

        function processReqChange() {
            if (req.readyState == 3) {
                try {
                    ProcessInput(req.responseText);

                    // At some (artibrary) length 
                    // recycle the connection
                    if (req.responseText.length > 3000) {
                        lastDelimiterPosition = -1;
                        getData();
                    }
                }
                catch (e) {
                    alert(e.message);
                }
            }
        }

        var lastDelimiterPosition = -1;

        function ProcessInput(input) {
            // Make a copy of the input
            var text = input;
            // Search for the last instance of the delimiter
            var nextDelimiter =
                  text.indexOf('|', lastDelimiterPosition + 1);
            if (nextDelimiter != -1) {
                // Pull out the latest message
                var timeStamp = text.substring(nextDelimiter + 1);
                if (timeStamp.length > 0) {
                    lastDelimiterPosition = nextDelimiter;
                    ProcessTime(timeStamp);
                }
            }
        }

        function ProcessTime(time) {
            var out = document.getElementById('outputZone');
            out.innerHTML = time;
        }
    </script>
</head>
<body onload="getData()">
    <b>Server Time:</b>&nbsp;&nbsp;<span id="outputZone"></span>
</body>
</html>
