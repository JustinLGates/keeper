<template>
  <div>
    <h1>{{keeps}}</h1>
  </div>
</template>

<script>
export default {
  name: "VaultDetails",

  mounted() {
    this.getKeeps();
  },
  computed: {
    keeps() {
      return this.$store.state.KeepsStore.keeps;
    }
  },
  methods: {
    getKeeps() {
      let data = {
        Id: this.$route.params.id
      };
      this.$store.dispatch("getKeepsByVaultId", data);
    }
  }
};
</script>

<style>
</style>