# POC For Sage Intacct API

## Overview

This is a POC for Sage Intacct API. It is a .NET Core 3.1 console application that demonstrates how to use the Sage Intacct API to perform basic operations.

## Getting Started

Sage intacct Client configuration to be added in progran.cs as constants

```csharp
const string senderId = "";
        const string senderPassword = "";
        const string userId = "";
        const string userPassword = "";
        const string companyId = "";
        const string entityId = "";
```

## Lookup Fields For Get Requests

The following code is used to retrieve the fields for a specific object. The object name is passed as a parameter to the Lookup object.

```csharp
    var client = new OnlineClient(_clientConfig);

    var lookup = new Lookup(Guid.NewGuid().ToString())
    {
        Object = "SODOCUMENT"
    };
    var lkpresult = await client.Execute(lookup);

```

## Intacct Links

The Intacct SDK documentation can be found [here](https://developer.intacct.com/tools/sdk-net/).

The Intacct API documentation can be found [here](https://developer.intacct.com/api/).

The Intacct Login page can be found [here](https://www-p04.intacct.com/ia/acct/login.phtml).