<template>
  <div class="dashboard container-fluid">
    <div class="row">
      <div class="col-12 col-md-12 text-center p-1">
        <h3 class="p-1">Welcome back username....</h3>
        <img class="profile-img-large" src="https://placehold.it/150" alt />
      </div>
      <div class="col-12 text-center">
        <button class="text-light btn btn-info btn-outline-dark m-1 my-2">Vaults</button>
        <button class="text-light btn btn-info btn-outline-dark m-1 my-2">Keeps</button>
      </div>
    </div>

    <div class="row">
      <!-- <div class="card-columns">
        insert vaults or keeps here...
      </div>-->
      <div class="col-12">
        <vault v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>
  </div>
</template>

<script>
import vault from "../components/Vault.vue";
export default {
  name: "dashboard",
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.vaults;
    }
  },
  methods: {
    CreateVault() {
      event.stopPropagation();
    }
  },
  components: {
    vault
  }
};
</script>

<style>
.profile-img-large {
  height: 8rem;
  width: 8rem;
  border-radius: 50%;
}
.mouse-show {
  opacity: 0;
}
/* may need to adjust this to .. */
.hide-show:hover .mouse-show {
  opacity: 1;
}
</style>
