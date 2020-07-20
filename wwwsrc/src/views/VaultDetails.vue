<template>
  <div>
    <h1>vault details</h1>
  </div>
</template>

<script>
export default {
  mounted() {
    this.$store.dispatch("getKeepsByVaultId", id);
  },
  mounted() {}
};
</script>

<style>
</style>