var app = angular.module('northwindApp', []);
app.service('nService', function ($http) {
    this.getProductsModel = function () {
        var pModel = $http({
            method: 'Get',
            url: '/Products/Liste'
        }).then(function (response) {
            return response.data;
            });
        return pModel;
    };
    this.getProductByID = function (ProductID) {
        var product = $http({
            method: 'Get',
            url: '/Products/Detay/',
            params: { id: ProductID }
        }).then(function (response) {
            return response.data;
            });
        return product;
    };
    this.updateProduct = function (productPar) {
        var product = $http({
            method: 'POST',
            url: '/Products/Guncel/',
            data: productPar
        }).then(function (response) {
            return response.data;
        });
        return product;
    };
    this.createProduct = function (productPar) {
        var product = $http({
            method: 'POST',
            url: '/Products/Ekle/',
            data: productPar
        }).then(function (response) {
            return response.data;
        });
        return product;
    };
    this.deleteProduct = function (productPar) {
        var product = $http({
            method: 'POST',
            url: '/Products/Sil/',
            data: productPar
        }).then(function (response) {
            return response.data;
        });
        return product;
    };

});

app.controller('productsController', function ($scope, nService) {
    $scope.getAllProducts = function () {
        nService.getProductsModel().then(function (result) {
            $scope.pList = result.plist; //Controllerdakiyle aynı result.plist 
            $scope.cList = result.clist;
            $scope.sList = result.slist;
            $scope.id = result.id;
        });
    };
    $scope.getProduct = function (ProductID) {
        nService.getProductByID(ProductID).then(function (result) {
            $scope.product = result.product; //Controllerdakiyle aynı result.product 
            $scope.detShow = true; 
        });
    };
    $scope.UptProduct = function (product) {
        nService.updateProduct(product).then(function (result) {
            $scope.Msg = result.ProductName + " Güncellendi ";
            $scope.getAllProducts();
        });
    };
    $scope.CreateProduct = function (product) {
        nService.createProduct(product).then(function (result) {
            $scope.Msg = result.ProductName + " Eklendi ";
            $scope.getAllProducts();
        });
    };
    $scope.DeleteProduct = function (product) {
        nService.deleteProduct(product).then(function (result) {
            $scope.Msg = result.ProductName + " Silindi ";
            $scope.getAllProducts();
        });
    };

});