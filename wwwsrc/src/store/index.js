import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { KeepsStore } from "./KeepsStore";
import { VaultStore } from "./VaultsStore";
import { api } from "./AxiosService";
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    publicKeeps: [],
  },
  mutations: {},
  actions: {
    setBearer({}, bearer) {
      api.defaults.headers.authorization = bearer;
    },
    resetBearer() {
      api.defaults.headers.authorization = "";
    },
  },
  modules: {
    KeepsStore,
    VaultStore,
  },
});
