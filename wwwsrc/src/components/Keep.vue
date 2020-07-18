<template>
  <div class>
    <div class="card-main shadow bg-light">
      <img src="http://placehold.it/150" class="card-img-top" alt="https://placehold.id/150" />
      <div class="card-body">
        <h5 class="card-title"></h5>
        <p class="card-text">
          {{keep}}
          <!-- {{keep.name}} -->
          <!-- {{keep.description}} -->
          <!-- {{keep.img}} -->
        </p>
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
.card-main {
  border-radius: 20px;
}
</style>