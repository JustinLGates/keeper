<template>
  <nav class="container-fluid">
    <div class="nav nav-pills bg-secondary text-primary row">
      <div class="d-flex justify-content-between col-12 p-0 m-0">
        <div class="d-flex align-items-center">
          <span>
            <i class="fa fa-star px-2 action"></i>
          </span>
          <!-- <span v-if="$auth.isAuthenticated" class="nav-item dropdown py-2">
            <a
              class="nav-link dropdown-toggle"
              data-toggle="dropdown"
              href="#"
              role="button"
              aria-haspopup="true"
              aria-expanded="false"
            >Popular</a>
            <div class="dropdown-menu">
              <a class="dropdown-item" href="#">New</a>
              <a class="dropdown-item" href="#">Mine</a>

              <div class="dropdown-divider"></div>
              <a class="dropdown-item" href="#">Popular</a>
            </div>
          </span>-->
        </div>
        <div class="d-flex align-items-center grow-1 w-100">
          <input class="searchBar w-100 p-2 mx-2" type="text" placeholder="Search..." />
        </div>
        <!-- <a class="nav-link disabled" href="#" tabindex="-1" aria-disabled="true">Disabled</a> -->
        <div class="d-flex align-items-center p-2">
          <button class="btn btn-success" @click="login" v-if="!$auth.isAuthenticated">Login</button>
          <button class="circle action p-0 m-0" v-else>
            <img
              @click="logout"
              class="circle proflieImg action p-0 m-0"
              src="https://placehold.it/150"
            />
          </button>
          <!-- <button class="btn btn-primary" @click="logout" v-else>logout</button> -->
          <i class="fas fa-chevron-down px-3 action"></i>
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
      console.log("this.$auth.user: ");
      console.log(this.$auth.user);
    },
    async logout() {
      this.$store.dispatch("resetBearer");
      await this.$auth.logout({ returnTo: window.location.origin });
    }
  }
};
</script>

<style >
.searchBar {
  border-radius: 20px;
  outline: none !important;
}
.action:hover {
  cursor: pointer;
  opacity: 0.5;
}
.circle {
  border-radius: 50%;
}
.proflieImg {
  width: 3rem;
  height: 3rem;
}
</style>
