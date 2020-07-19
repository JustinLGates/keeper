import { api } from "./AxiosService";

export const KeepsStore = {
  state: {
    publicKeeps: [],
  },
  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
  },
  actions: {
    async getPublicKeeps({ commit }) {
      let res = await api.get("keeps");
      // TODO REMOVE CONSOLE LOG
      console.log(res.data);
      commit("setPublicKeeps", res.data);
    },
    async createKeep({ commit, dispatch }, data) {
      let res = await api.post("keeps", data);
      // TODO REMOVE CONSOLE LOG
      console.log(res.data);
    },
  },
};
