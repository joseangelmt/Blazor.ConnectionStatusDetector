# Blazor.ConnectionStatusDetector

This package provides the *ConnectionStatusDetectorService* that provides the *ConnectionStatusChanged* event that notifies changes in the connection status on the client side.
Apart from the event, the service has the property *IsOnline* to query the connection status.

In addition, the *Connection* component is provided which renders different fragments depending on the connection status.

To use it, link to *connection.js* in your *index.html* file:

```html
<script src="_content/Blazor.ConnectionStatusDetector/connection.js"></script>
```

Then register the service in yout *Program.cs*:

```cs
services.AddSingleton<IConnectionStatusDetectorService, ConnectionStatusDetectorService>();
```

To render different fragments based on the connection status, import the namespace in you *__Imports.razor_* file: 

```csharp
@using Blazor.ConnectionStatusDetector
```

 add a *Connection* component in your razor files, like:

```html
<Connection>
    <Online>
        <h1 style="color: green">Online</h1>
    </Online>
    <Offline>
        <h1 style="color: red">Offline</h1>
    </Offline>
</Connection>
```
