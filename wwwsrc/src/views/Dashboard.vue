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
      <div class="col-12 py-3">
        <div v-if="this.showVaults" class="card-columns">
          <vault class="card" v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
        </div>
        <div v-else class="card-columns">
          <vault class="card" v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
        </div>
        <keep
          class="card bg-secondary input-round-1 shadow"
          v-for="keep in keeps"
          :key="keep.id"
          :keepData="keep"
        />
      </div>
    </div>
  </div>
</template>

<script>
import vault from "../components/Vault.vue";
export default {
  name: "dashboard",
  data() {
    return {
      showVaults: true
    };
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.vaults;
    },
    keeps() {
      return this.$store.state.KeepsStore.userKeeps;
    }
  },
  components: {
    vault
  }
};
</script>

<style>
</style>
