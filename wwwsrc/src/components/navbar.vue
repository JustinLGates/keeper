<template>
  <nav class="container-fluid shadow">
    <div class="nav nav-pills bg-secondary text-primary row">
      <div class="d-flex justify-content-between col-12 p-0 m-0">
        <div class="d-flex align-items-center">
          <span>
            <router-link to="/">
              <i class="fa fa-star mx-1 mx-sm-2 mx-md-3 action"></i>
            </router-link>
          </span>
        </div>
        <div class="d-flex align-items-center grow-1 my-2 mx-1 mx-sm-2 mx-md-3 w-100">
          <input class="input-round w-100 p-2" type="text" placeholder="Search..." />
        </div>
        <div class="d-flex align-items-center">
          <span v-if="!$auth.isAuthenticated" class="p-0 mx-1 mx-sm-2 mx-md-3 input-round-2">
            <button class="btn btn-success input-round-1 text-light" @click="login">Login</button>
          </span>
          <div class="d-flex align-items-center" v-else>
            <router-link to="/dashboard">
              <img class="circle proflieImg action p-1" src="https://placehold.it/150" />
            </router-link>
            <div class="d-flex mx-1 mx-sm-2 mx-md-3">
              <div class="dropdown">
                <span
                  @click="getVaults"
                  type="button"
                  id="dropdownMenuOffset"
                  data-toggle="dropdown"
                  aria-haspopup="true"
                  aria-expanded="false"
                  data-offset="-145,20"
                >
                  <i class="fas fa-chevron-down"></i>
                </span>
                <div class="dropdown-menu bg-secondary" aria-labelledby="dropdownMenuOffset">
                  <a
                    class="dropdown-item text-primary"
                    type="button"
                    data-toggle="modal"
                    data-target="#keepFormModal"
                  >Create Keep</a>
                  <a
                    class="dropdown-item text-primary"
                    type="button"
                    data-toggle="modal"
                    data-target="#vaultFormModal"
                  >Create Vault</a>
                  <a
                    class="dropdown-item text-primary"
                    type="button"
                    data-toggle="modal"
                    data-target="#optionsFormModal"
                  >Search Options</a>
                  <a @click="logout" class="dropdown-item text-primary" href="#">Sign out</a>
                </div>
              </div>
            </div>
          </div>

          <!-- <button class="btn btn-primary" @click="logout" v-else>logout</button> -->
        </div>
      </div>
    </div>
  </nav>
</template>

<script>
import axios from "axios";

let _api = axios.create({
  baseURL: "https://localhost:5001",
  withCredentials: true
});
export default {
  name: "Navbar",
  methods: {
    async login() {
      await this.$auth.loginWithPopup();
      this.$store.dispatch("setBearer", this.$auth.bearer);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    },
    getVaults() {
      this.$store.dispatch("getVaults");
    }
  }
};
</script>

<style >
</style>
