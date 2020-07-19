import { api } from "./AxiosService";

export const VaultStore = {
  state: {
    vaults: [{ Name: "test", Description: "its a test" }],
  },
  mutations: {
    setVaults(state, vaults) {
      state.vaults = vaults;
    },
  },
  actions: {
    async getVaults({ commit }) {
      try {
        let res = await api.get("vaults");
        commit("setVaults", res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async createVault({ commit, dispatch }, data) {
      let res = await api.post("vaults", data);
      // TODO REMOVE CONSOLE LOG
      console.log("create");
    },
  },
};
