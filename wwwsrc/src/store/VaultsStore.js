import { api } from "./AxiosService";

export const VaultsStore = {
  state: {
    vaults: [],
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
      try {
        await api.post("vaults", data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
