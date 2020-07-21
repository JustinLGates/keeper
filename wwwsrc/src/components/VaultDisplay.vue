<template>
  <div class="row">
    <div class="col-12">
      <div class="card-columns">
        <vault class="card" v-for="vault in vaults" :key="vault.id" :vaultData="vault" />
      </div>
    </div>
  </div>
</template>


 <script>
import vault from "../components/Vault.vue";
export default {
  name: "vaultDisplay",
  data() {
    return {};
  },
  mounted() {
    this.$store.dispatch("getVaults");
  },
  computed: {
    vaults() {
      return this.$store.state.VaultsStore.vaults;
    }
  },
  components: {
    vault
  }
};
</script>

<style>
</style>
    

