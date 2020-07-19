import { api } from "./AxiosService";

export const VaultStore = {
  state: {
    vaults: [],
  },
  mutations: {
    setUserVaults(state, vaults) {
      state.vaults = vaults;
    },
  },
  actions: {
    async getVaults({ commit }, id) {
      // let res = await api.get("vaults/" + id);
      // TODO REMOVE CONSOLE LOG
      console.log("geting vaults....");
      // commit("setVaults", res.data);
    },
    async createVault({ commit, dispatch }, data) {
      // let res = await api.post("vaults", data);
      // TODO REMOVE CONSOLE LOG
      console.log("create");
    },
  },
};
