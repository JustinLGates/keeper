<template>
  <div class="hide-show">
    <div class="card input-round-1 bg-secondary text-light">
      <img class="w-100 round-top" :src="keep.img" />
      <h5 class="text-primary">{{keep.name}}</h5>
      <!--  TODO MAKE A METHOD TO HANDLE Details -->

      <!--  TODO MAKE A METHOD TO HANDLE ADDING KEEP TO A USERS VAULT -->
      <p class="px-2">{{keep.description}}</p>
      <div class="d-flex justify-content-between p-2">
        <button
          @click="CreateKeepReferance"
          class="btn btn-info input-round-1 text-light mouse-show"
        >Keeper</button>
        <span
          type="button"
          class="hide-show"
          data-toggle="modal"
          data-target="#keepDetailsModal"
        >dets</span>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: ["keep"]
};
</script>

<style>
.round-top {
  border-top-left-radius: 20px;
  border-top-right-radius: 20px;
}
</style>