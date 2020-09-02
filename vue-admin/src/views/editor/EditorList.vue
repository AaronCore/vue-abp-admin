<template>
<div>
    <!-- 富文本编辑器组件 -->
    <quill-editor v-model="introduce"></quill-editor>
    <!-- 添加商品的按钮 -->
    <el-button type="primary" class="btnAdd" @click="add">添加</el-button>
</div>
</template>

<script>
export default {
    data() {
        return {
            introduce: ''
        }
    },
    methods: {
        add() {
            console.log(this.introduce)
        }
    }
}
</script>

<style lang="less" scoped>
.btnAdd {
    margin-top: 15px;
}
</style>
