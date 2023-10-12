# ElasticLoggerApi

This project uses ElasticSearch & Kibana for logging purpose

# Getting started
- Install ElasticSearch & Kibana to Ubuntu Server. [[Details]](https://linux.how2shout.com/how-to-install-kibana-dashboard-on-ubuntu-22-04-20-04-lts)
- Clone this project. Like a normal .NET project, you can run it by <code>dotnet run</code> command.
- On <code>appsettings.json</code>:
  - The default port is 7500. Change it as you desired.
  - <code>LoggerType</code> can accept "Elastic" or "Console" value.
- The default ElasticSearch URL is http://localhost:9200.
- Publish the project, then put it anywhere on Ubuntu Server (typically on your home directory). Test the app by running <code>dotnet ElasticLoggerApi.dll</code> from the app location.
- If you want, you can create systemctl service for this app.
- Next, please configure Kibana that has been installed on Ubuntu Server. [[Details]](https://dev.to/mattqafouri/writing-logs-into-elastic-with-nlog-elk-and-net-5-0-246c)
