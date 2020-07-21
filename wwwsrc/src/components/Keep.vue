<template>
  <div class="hide-show">
    <div
      @click="setActiveKeep"
      class="card input-round-1 bg-secondary text-light"
      type="button"
      data-toggle="modal"
      data-target="#keepDetailsModal"
    >
      <img class="w-100 input-round-top" :src="keepData.img" alt="Bad url" />
      <h5 class="text-primary">{{keepData.name}}</h5>
      <h5>
        <i class="fas fa-eye"></i>
        {{keepData.views}}
      </h5>
      <h5>keeps {{keepData.keeps}}</h5>
      <p class="px-2">description {{keepData.description}}</p>
      <div class="d-flex justify-content-between p-2"></div>
    </div>
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
      this.addView();
    },
    addView() {
      this.keepData.views++;
      this.$store.dispatch("updateKeeps", this.keepData);
    }
  }
};
</script>

<style>
.mouse-show {
  opacity: 0;
}
</style>