<template>
  <div>
    <h1
      class="bg-secondary text-light rounded-bottom shadow rounded p-2 m-2 text-center"
    >{{this.$route.params.name}} vault</h1>
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
    let data = {
      id: this.$route.params.id,
      done: true
    };
    this.$store.dispatch("getVaultKeeps", data);
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