import { ApolloServer } from "apollo-server-express";
import { DataSources } from "apollo-server-core/dist/graphqlOptions";
import express from "express";
import { getConfig } from "./config";
import resolvers from "./resolvers";
import schema from "./schema";
import { ThingsStore } from "./services";

const { PORT, API_URI } = getConfig();
const app = express();
const thingsStore = new ThingsStore({
  url: API_URI,
});
const server = new ApolloServer({
  resolvers,
  dataSources: (): DataSources<{
    thingsStore: ThingsStore;
  }> => {
    return {
      thingsStore,
    };
  },
  typeDefs: schema,
  playground: {
    settings: {
      "editor.theme": "dark",
    },
  },
});

server.applyMiddleware({ app });

app.listen(PORT, () =>
  console.log(`GraphQL Server is now running on port ${PORT}.`),
);
