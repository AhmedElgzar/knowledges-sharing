from django.db import models


class Track(models.Model):
    name = models.CharField(max_length=256)
    artist = models.CharField(max_length=256)
    url = models.FileField(upload_to='mp3/%Y/%m/%d',)
    rate = models.IntegerField()


class Playlist(models.Model):
    name = models.CharField(max_length=256)
    tracks = models.ManyToManyField(Track, verbose_name="list of tracks")


# Receive the pre_delete signal and delete the file associated with the model instance.
from django.db.models.signals import pre_delete
from django.dispatch.dispatcher import receiver

@receiver(pre_delete, sender=Track)
def track_delete(sender, instance, **kwargs):
    # Pass false so FileField doesn't save the model.
    instance.url.delete(False)