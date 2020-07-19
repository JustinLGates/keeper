import Vue from "vue";
import Vuex from "vuex";
import Axios from "axios";
import router from "../router";
import { KeepsStore } from "./KeepsStore";
import { VaultStore } from "./VaultsStore";
import { setBearer } from "../store/AxiosService";
import { resetBearer } from "../store/AxiosService";
export { api } from "../store/AxiosService";
Vue.use(Vuex);

export default new Vuex.Store({
  state: {
    publicKeeps: [],
  },
  mutations: {},
  actions: {},
  modules: {
    KeepsStore,
    VaultStore,
  },
});
