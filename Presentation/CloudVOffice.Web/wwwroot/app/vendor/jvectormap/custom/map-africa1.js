// Africa
$(function(){
	$('#mapAfrica').vectorMap({
		map: 'africa_mill',
		backgroundColor: '#ffffff',
		scaleColors: ['#707C8E'],
		zoomOnScroll:false,
		zoomMin: 1,
		hoverColor: true,
		series: {
			regions: [{
				values: gdpData,
				scale: ['#239d2c', '#e5e8f2'],
				normalizeFunction: 'polynomial'
			}]
		},
	});
});