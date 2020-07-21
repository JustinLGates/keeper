<template>
  <div class="hide-show">
    <div
      @click="setActiveKeep"
      class="card input-round-1 bg-secondary text-light"
      type="button"
      data-toggle="modal"
      data-target="#keepDetailsModal"
    >
      <img class="w-100 input-round-top p-absolute" :src="keepData.img" alt="Bad url" />
      <div class="d-flex justify-content-between p-2">
        <h5 class="text-primary">{{keepData.name}}</h5>
        <div class="mouse-show">
          <i class="fas fa-eye"></i>
          {{keepData.views}}
        </div>
        <div class="mouse-show">
          <i class="fas fa-bookmark"></i>
          {{keepData.keeps}}
        </div>
      </div>
      <p class="px-2 mouse-show">description {{keepData.description}}</p>
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
.p-absolute {
}
.mouse-show {
  opacity: 0;
}
</style>