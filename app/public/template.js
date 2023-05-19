var list = $('.item'),
	hb = $('.hamburger'),
	targets = $('.target'),
	links = $('.link'),
	open = false;

function build() {	
	var z = 7;
	$.each(list, function(){
		$(this).css("z-index", z);
		z--;
		$(this).addClass($(this).attr("id"));
	})
}

build();

function hide_ingredients() {
	$("#cheese").hide();
	$("#burger").hide();
	$("#bacon").hide();
	$("#pickle").hide();
	$("#lettuce").hide();
	$("#tomato").hide();
}

function explode_burger() {
	$.each(list, function(){
		var self = this;
		var id = $(this).attr('id');	
		un_hover_burger();	
		setTimeout(function(){
			console.log($(self));
			$(self).addClass(id + "-explode");	
		}, 300);
	});
}

function shrink_burger() {
	$.each(list, function(){
		var explodeClass = $(this).attr("id") + "-explode";
		$(this).removeClass(explodeClass);
	});
}

function hover_burger() {
	$.each(list, function(){
		var id = $(this).attr('id');
		$(this).addClass(id + "-hover");
	});
}

function un_hover_burger() {
	$.each(list, function(){
		var id = $(this).attr('id');
		$(this).removeClass(id + "-hover");
	});
}

$('a').click(function(e){
	e.preventDefault();
});

$(hb).click(function(){
	if (open === false) {
		explode_burger();
		open = true;
	} else {
		$(this).children('.link').removeClass('slide-in');
		$(this).children('svg').attr("class", "");
		shrink_burger();
		open = false;
	}
});

$(hb).hover(function(){
	if (open === false) {
		hover_burger();
		$('.shadow').addClass('fade-out');
	}
}, function(){
	if (open === false) {
		un_hover_burger();
		$('.shadow').removeClass('fade-out');
	}
});

$(list).hover(function(){
	if (open === true) {
		$(this).children('.link').addClass('slide-in');
		$(this).children('svg').attr("class", "fade");
	}
}, function(){
	$(this).children('.link').removeClass('slide-in');
	$(this).children('svg').attr("class", "");
});
