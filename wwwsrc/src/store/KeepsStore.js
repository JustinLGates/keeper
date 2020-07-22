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
    addKeep(state, keep) {
      state.keeps.push(keep);
    },
  },
  actions: {
    async getVaultKeeps({ commit, dispatch }, data) {
      try {
        let res = await api.get("vaults/" + data.id + "/keeps");
        if (data.done == true) {
          commit("setKeeps", res.data);
        } else return res.data;
      } catch (error) {
        console.error(error);
      }
    },
    async getUserVaultKeeps({ commit, dispatch }, data) {
      commit("setKeeps", data);
    },

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
    async getKeepsByVaultId({ commit }, id) {
      commit("setKeeps", []);
      try {
        let res = await api.get("keeps/vault/" + id);
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(Error);
      }
    },
    async createKeep({ commit, dispatch }, data) {
      try {
        let newKeep = await api.post("keeps", data);
        dispatch("getPublicKeeps", newKeep);
      } catch (error) {
        console.error(error);
      }
    },
    async updateKeeps({ commit, dispatch }, data) {
      try {
        let res = api.put("keeps/" + data.id, data);
      } catch (error) {}
    },
    async deleteVaultKeep({ commit, dispatch }, id) {
      try {
        let res = await api.delete("vaultkeeps/" + id);
        console.log(res.data);
      } catch (error) {
        console.error(error);
      }
    },
    async getAllUserKeeps({ commit, dispatch }) {
      try {
        let res = await api.get("keeps/user");
        commit("setKeeps", res.data);
      } catch (error) {
        console.error(error);
      }
    },
  },
};
