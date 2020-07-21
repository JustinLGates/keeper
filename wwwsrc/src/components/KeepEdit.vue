<template>
  <div
    class="card input-round-1 bg-secondary text-light"
    type="button"
    data-toggle="modal"
    data-target="#keepEditModal"
  >
    <img class="w-100 input-round-top" :src="keepData.img" />
    <h5 class="text-primary">{{keepData.name}}</h5>
    <p class="px-2">{{keepData.description}}</p>
    <div class="d-flex justify-content-between p-2"></div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"],
  methods: {
    setActiveKeep() {
      this.$store.dispatch("setActiveKeep", this.keepData);
      if (this.$store.state.VaultsStore.vaults.length < 1) {
        this.$store.dispatch("getVaults");
      }
    }
  }
};
</script>

<style>
</style>