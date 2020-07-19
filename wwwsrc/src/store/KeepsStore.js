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
      try {
        let res = await api.get("keeps");
        commit("setPublicKeeps", res.data);
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
