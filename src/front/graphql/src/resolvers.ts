import { IResolvers } from "apollo-server-express";
import { Thing } from "models";

const resolvers: IResolvers = {
  Query: {
    async thing(_, { id }, { dataSources }): Promise<Thing> {
      const retval = await dataSources.unitStore.getById(id);
      return retval;
    },
  },
};

export default resolvers;
