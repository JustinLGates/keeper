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
      console.log(res.data);
      commit("setPublicKeeps", res.data);
    },
  },
};
