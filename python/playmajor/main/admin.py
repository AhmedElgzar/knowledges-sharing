from django.contrib import admin
from main.models import Track, Playlist


class TrackAdmin(admin.ModelAdmin):
    list_display = ['name', 'artist', 'url', 'rate']
    list_filter = ['name', 'artist']
    search_fields = ['name', 'artist']


'''class PlaylistAdmin(admin.ModelAdmin):
    list_display = ['name']
    list_filter = ['name']
    fieldsets = [
        (None, {'fields': ['name']}),
    ]
'''
admin.site.register(Track, TrackAdmin)
#admin.site.register(Playlist, PlaylistAdmin)
