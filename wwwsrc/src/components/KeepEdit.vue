<template>
  <div class="card input-round-1 bg-secondary text-light">
    <div class="hide-show">
      <img class="w-100 input-round-top" :src="keepData.img" />
      <h5 class="text-primary">{{keepData.name}}</h5>
      <button
        @click.stop="deleteVaultKeep"
        class="btn btn-danger btn-outline-danger text-light mouse-show btn-top-right input-round-1"
      >Delete</button>
      <p class="px-2 mouse-show">{{keepData.description}}</p>
      <button
        class="btn btn-info btn-outline-info text-light mouse-show btn-bottom-right input-round-1"
        type="button"
        data-toggle="modal"
        data-target="#keepEditModal"
      >View</button>
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
    },
    async deleteVaultKeep() {
      await this.$store.dispatch("deleteVaultKeep", this.keepData.vaultKeepId);
      let data = {
        id: this.$route.params.id,
        done: true
      };
      this.$store.dispatch("getVaultKeeps", data);
    }
  }
};
</script>

<style>
.btn-top-right {
  position: absolute;
  top: 8px;
  right: 8px;
}
.btn-bottom-right {
  position: absolute;
  bottom: 8px;
  right: 8px;
}
</style>