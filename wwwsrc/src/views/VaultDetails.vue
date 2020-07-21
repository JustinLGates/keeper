<template>
  <div>
    <h1>{{this.$route.params.name}}</h1>
    <div class="card-columns p-1 px-sm-2">
      <KeepEdit v-for="keep in keeps" :key="keep.id" :keepData="keep" />
    </div>
  </div>
</template>

<script>
import KeepEdit from "../components/KeepEdit";
export default {
  name: "VaultDetails",

  mounted() {
    this.getVaultData();
  },
  computed: {
    keeps() {
      return this.$store.state.KeepsStore.keeps;
    },
    vault() {
      return this.$store.state.VaultStore.activeVault;
    }
  },
  methods: {
    getVaultData() {
      this.$store.dispatch("getKeepsByVaultId", this.$route.params.id);
    }
  },
  components: {
    KeepEdit
  }
};
</script>

<style>
</style>