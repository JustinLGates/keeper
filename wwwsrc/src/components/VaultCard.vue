<template>
  <div class="col-12 col-md-4 w-100 p-1 px-sm-3">
    <div class="card bg-secondary w-100 text-light p-1 px-sm-2">
      <h4 class="text-primary">{{vaultData.Name}}</h4>
      <p class="px-2">{{vaultData.Description}}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {};
  },
  props: ["vaultData"]
};
</script>

<style>
</style>