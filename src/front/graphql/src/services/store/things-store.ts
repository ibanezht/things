import { RESTDataSource } from "apollo-datasource-rest";
import StoreOptions from "./store-options";
import { Thing } from "models";

class ThingsStore extends RESTDataSource {
  constructor(storeOptions: StoreOptions) {
    super();
    this.baseURL = storeOptions.url;
  }

  public async getById(id: string): Promise<Thing> {
    return await this.get(`api/things/${id}`);
  }
}

export default ThingsStore;
