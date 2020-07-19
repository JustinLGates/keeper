<template>
  <div class="hide-show">
    <div class="card input-round-1 bg-secondary text-light">
      <img class="w-100 input-round-top" :src="keepData.img" />
      <h5 class="text-primary">{{keepData.name}}</h5>
      <!--  TODO MAKE A METHOD TO HANDLE Details -->

      <!--  TODO MAKE A METHOD TO HANDLE ADDING KEEP TO A USERS VAULT -->
      <p class="px-2">{{keepData.description}}</p>
      <div class="d-flex justify-content-between p-2">
        <button class="btn btn-info input-round-1 text-light mouse-show">Keep</button>
        <span
          type="button"
          class="mouse-show"
          data-toggle="modal"
          data-target="#keepDetailsModal"
        >dets</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "Keep",
  props: ["keepData"]
};
</script>

<style>
.mouse-show {
  opacity: 0;
}
</style>