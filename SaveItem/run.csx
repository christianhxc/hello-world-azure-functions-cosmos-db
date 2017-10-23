using System.Net;

public static HttpResponseMessage Run(HttpRequestMessage req, TraceWriter log, out object document)
{
    log.Info("C# HTTP trigger function processed a request.");

    // parse query parameter
    string qsTask = req.GetQueryNameValuePairs()
        .FirstOrDefault(q => string.Compare(q.Key, "task", true) == 0)
        .Value;

    document = new {
        task = qsTask,
        username = "christianhxc"
    };

    return qsTask == null
        ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
        : req.CreateResponse(HttpStatusCode.OK, "Task: " + qsTask);
}
