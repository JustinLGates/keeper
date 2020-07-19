import { api } from "./AxiosService";

export const KeepsStore = {
  state: {
    publicKeeps: [],
    userKeeps: [],
    activeKeep: {},
  },
  mutations: {
    setPublicKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setUserKeeps(state, keeps) {
      state.publicKeeps = keeps;
    },
    setActiveKeep(state, keep) {
      state.activeKeep = keep;
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
    setActiveKeep({ commit }, keep) {
      commit("setActiveKeep", keep);
    },
    //TODO ADD THIS ROUTE IN THE SERVER
    async getUserKeeps({ commit }) {
      try {
        let res = await api.get("keeps/all");
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
