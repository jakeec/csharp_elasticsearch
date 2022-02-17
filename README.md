Playing with Elasticsearch in C# 10 / .NET Core 6 to get a feel for the [NEST client](https://www.elastic.co/guide/en/elasticsearch/client/net-api/current/nest.html).

## Setup

In appsettings.Development.json an Elasticsearch configuration section has basic auth credentials which will need to be filled in. 

Elasticsearch and Kibana were setup locally following this tutorial: https://www.youtube.com/watch?v=gS_nHTWZEJ8&list=PL_mJOmq4zsHZYAyK606y7wjQtC0aoE6Es

First time setup of elasticsearch gives you credentials and a token to get into kibana.

I used [this news category data set](https://www.kaggle.com/rmisra/news-category-dataset). You have to make an account but it's free.

Once everything is up and running and the dataset is imported you can run this application which is a basic MVC app with a search bar that proxies through to elasticsearch to query the dataset.

Everything to do with Elasticsearch config and query specification is in the SearchEngine class. By default the query will search for the user-provided term using an OR operator (i.e. if any of the space-delimited terms are present rather than all terms having to be present) against the short_description field of the documents.

## Notes

