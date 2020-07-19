import { api } from "./AxiosService";

export const KeepsStore = {
  state: {
    publicKeeps: [],
    keep: {},
  },
  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
  },
  actions: {
    async getPublicKeeps({ commit }) {
      let res = await api.get("keeps");
      commit("setPublicKeeps", res.data);
    },
    async createKeep({}, data) {
      await api.post("keeps", data);
    },
  },
};
