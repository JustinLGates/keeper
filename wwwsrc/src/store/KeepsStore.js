import { api } from "./AxiosService";

export const KeepsStore = {
  state: {
    keeps: [],
    activeKeep: {},
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
    },
  },
  actions: {
    async getPublicKeeps({ commit }) {
      try {
        let res = await api.get("keeps");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(Error);
      }
    },
    setActiveKeep({ commit }, keep) {
      commit("setActiveKeep", keep);
    },
    async getKeepsByVaultId({ commit }, vault) {
      commit("setKeeps", []);
      try {
        let res = await api.get("keeps/" + vault.Id);
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(Error);
      }
    },
    async createKeep({}, data) {
      try {
        await api.post("keeps", data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
