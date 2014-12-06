from django.conf.urls import patterns, url
from main import views
from playmajor import settings
from django.conf.urls.static import static


urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'playmajor.views.home', name='home'),
    url(r'^$', views.index, name='index'),
) + static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)